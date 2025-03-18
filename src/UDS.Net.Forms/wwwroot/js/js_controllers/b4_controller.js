// wwwroot/js/js_controllers/autocalculate_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["CDRSUM", "CDRGLOB", "MEMORY", "ORIENT", "JUDGMENT", "COMMUN", "HOMEHOBB", "PERSCARE"];

    updateCDRSUM() {
        const memoryValue = this.getFloatValueFor("MEMORY");
        const orientValue = this.getFloatValueFor("ORIENT");
        const judgmentValue = this.getFloatValueFor("JUDGMENT");
        const communValue = this.getFloatValueFor("COMMUN");
        const homehobbValue = this.getFloatValueFor("HOMEHOBB");
        const perscareValue = this.getFloatValueFor("PERSCARE");

        let result = null;
        const secondaryScores = [orientValue, judgmentValue, communValue, homehobbValue, perscareValue];
        let sum = memoryValue + orientValue + judgmentValue + communValue + homehobbValue + perscareValue;

        // set value of CDRSUM
        this.CDRSUMTarget.value = sum;

        // Handling M = 0.5 or M = 0
        if (memoryValue === 0.5) {
            const countScoresGreaterThanEqual1 = secondaryScores.filter(score => score >= 1).length;

            if (countScoresGreaterThanEqual1 >= 3) {
                result = 1;
            } else {
                result = 0.5;
            }
        } else if (memoryValue === 0) {
            const countScoresGreaterThanEqual05 = secondaryScores.filter(score => score >= 0.5).length;

            // CDR = 0.5 if there are at least 2 scores >= 0.5
            if (countScoresGreaterThanEqual05 >= 2) {
                result = 0.5;
            } else {
                result = 0;
            }
        }

        // When 3 categories = MEMORY, then CDR = MEMORY
        else if (memoryValue >= 0) {
            const scoresSimilarToM = secondaryScores.filter(score => score === memoryValue);

            if (scoresSimilarToM.length >= 3) {
                result = memoryValue;
            }

            // Majority rule (greater/less than memory)
            else {
                const greaterThanMemoryMap = {};
                const lessThanMemoryMap = {};

                secondaryScores.forEach(score => {
                    if (score > memoryValue) {
                        greaterThanMemoryMap[score] = (greaterThanMemoryMap[score] || 0) + 1;
                    } else if (score < memoryValue) {
                        lessThanMemoryMap[score] = (lessThanMemoryMap[score] || 0) + 1;
                    }
                });

                // Count total entries on each side
                const greaterThanCount = Object.values(greaterThanMemoryMap).reduce((acc, count) => acc + count, 0);
                const lessThanCount = Object.values(lessThanMemoryMap).reduce((acc, count) => acc + count, 0);

                // Case 1: 3 or more on the greater side of M, then CDR = secondary categories
                if (greaterThanCount >= 3) {
                    const majorityGreaterScore = Object.entries(greaterThanMemoryMap).reduce((prev, current) =>
                        prev[1] > current[1] ? prev : current
                    );
                    result = parseFloat(majorityGreaterScore[0]);
                    console.log("case 1 met");
                }
                // Case 2: 3 or more on the lesser side of M, then CDR = secondary categories
                else if (lessThanCount >= 3) {
                    const majorityLessScore = Object.entries(lessThanMemoryMap).reduce((prev, current) =>
                        prev[1] > current[1] ? prev : current
                    );
                    result = parseFloat(majorityLessScore[0]);
                    console.log("case 2 met");
                }
                // Case 3: 3 on one side and 2 on the other side, then CDR = MEMORY
                else if ((greaterThanCount === 3 && lessThanCount === 2) ||
                    (lessThanCount === 3 && greaterThanCount === 2)) {
                    console.log("case 3 met");
                    result = memoryValue;
                }

                // Tied scores closest to M
                else {
                    // For the greater side, find the closest scores to M
                    const greaterSideScores = Object.keys(greaterThanMemoryMap).map(Number);
                    const closestGreaterScores = greaterSideScores.filter(score => score !== memoryValue)
                        .sort((a, b) => Math.abs(a - memoryValue) - Math.abs(b - memoryValue));
                    console.log("Tied scores closest to M");
                    // For the lesser side, find the closest scores to M
                    const lessSideScores = Object.keys(lessThanMemoryMap).map(Number);
                    const closestLessScores = lessSideScores.filter(score => score !== memoryValue)
                        .sort((a, b) => Math.abs(a - memoryValue) - Math.abs(b - memoryValue));

                    // If there is a tie on either side, select the closest scores to M
                    if (greaterThanCount === 2 && lessThanCount === 2) {
                        if (closestGreaterScores.length > 0 && closestLessScores.length > 0) {
                            result = Math.abs(closestGreaterScores[0] - memoryValue) < Math.abs(closestLessScores[0] - memoryValue)
                                ? closestGreaterScores[0]
                                : closestLessScores[0];
                            console.log("Tie case met, selected closest score");
                        }
                    } else {
                        console.log("No other rule applying")
                        result = memoryValue;
                    }
                }
            }
        }
        this.updateCRGLOB(result);
    }

    updateCRGLOB(result) {
        this.CDRGLOBTargets.forEach((radioButton) => {
            radioButton.checked = parseFloat(radioButton.value) === result;
        });
        console.log(`CDRGLOB set to: ${result}`);
    }


    getFloatValueFor(targetName) {
        const targetArray = this[`${targetName}Targets`];
        if (!targetArray || !targetArray.length) {
            return 0;
        }
        const selectedRadio = targetArray.find(el => el.checked);
        return selectedRadio ? parseFloat(selectedRadio.value) : 0;
    }
}
