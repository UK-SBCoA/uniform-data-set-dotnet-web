import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["CDRSUM", "CDRGLOB", "MEMORY", "ORIENT", "JUDGMENT", "COMMUN", "HOMEHOBB", "PERSCARE"];

    updateCDRSUM() {
        const memoryValue = this.getFloatValue("MEMORY");
        const orientValue = this.getFloatValue("ORIENT");
        const judgmentValue = this.getFloatValue("JUDGMENT");
        const communValue = this.getFloatValue("COMMUN");
        const homehobbValue = this.getFloatValue("HOMEHOBB");
        const perscareValue = this.getFloatValue("PERSCARE");

        let result = null;
        const secondaryScores = [orientValue, judgmentValue, communValue, homehobbValue, perscareValue];
        let sum = memoryValue + orientValue + judgmentValue + communValue + homehobbValue + perscareValue;

        // set value of CDRSUM
        this.CDRSUMTarget.value = sum;

        if (memoryValue === 0.5 && secondaryScores.every(score => score === 0)) {
            result = 0.5;
            this.updateCRGLOB(result);
            return;
        }

        if (memoryValue === 0.5) {
            const countScoresGreaterThanEqual1 = secondaryScores.filter(score => score >= 1).length;
            const result = countScoresGreaterThanEqual1 >= 3 ? 1 : 0.5;
            this.updateCRGLOB(result);
            return;
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
        if (memoryValue >= 0) {
            // If Memory is 1 or greater, CDR has to be at least 0.5
            if (memoryValue >= 1) {
                const zeroCount = secondaryScores.filter(score => score === 0).length;
                if (zeroCount >= 3) {
                    result = 0.5;
                    this.updateCRGLOB(result);
                    return;
                }
            }
            const scoresSimilarToM = secondaryScores.filter(score => score === memoryValue);

            if (scoresSimilarToM.length >= 3) {
                result = memoryValue;
                this.updateCRGLOB(result);
                return;
            }

            // Majority rule (greater/less than memory).
            else {
                const greaterThanMemoryMap = {};
                const lessThanMemoryMap = {};

                secondaryScores.forEach(score => {
                    if (score === 0) return;
                    if (score > memoryValue) {
                        greaterThanMemoryMap[score] = (greaterThanMemoryMap[score] || 0) + 1;
                    } else if (score < memoryValue) {
                        lessThanMemoryMap[score] = (lessThanMemoryMap[score] || 0) + 1;
                    }
                });

                const greaterThanCount = Object.values(greaterThanMemoryMap).reduce((acc, count) => acc + count, 0);
                const lessThanCount = Object.values(lessThanMemoryMap).reduce((acc, count) => acc + count, 0);

                // Case 1: 3 or more on the greater side of M, then CDR = secondary categories.
                if (greaterThanCount >= 3 && lessThanCount != 2) {
                    const majorityGreaterScore = Object.entries(greaterThanMemoryMap).reduce((prev, current) =>
                        prev[1] > current[1] ? prev : current
                    );
                    result = parseFloat(majorityGreaterScore[0]);
                }

                // Case 2: 3 or more on the lesser side of M, then CDR = secondary categories.
                else if (lessThanCount >= 3) {
                    const majorityLessScore = Object.entries(lessThanMemoryMap).reduce((prev, current) =>
                        prev[1] > current[1] ? prev : current
                    );
                    result = parseFloat(majorityLessScore[0]);
                }

                // Case 3: 3 on one side and 2 on the other side, then CDR = MEMORY.
                if ((greaterThanCount === 3 && lessThanCount === 2) ||
                    (lessThanCount === 3 && greaterThanCount === 2)) {
                    result = memoryValue;
                    this.updateCRGLOB(result);
                    return;
                }

                // Tied scores cases
                // If we have 2 tie blocks (two categories each) on both sides of M, then CDR = M.
                if (greaterThanCount <= 2 && lessThanCount <= 2) {
                    result = memoryValue; 
                }
                else if (greaterThanCount >= 3 && lessThanCount != 2) {
                    // Case 1: Majority rule on the greater side of M.
                    const majorityGreaterScore = Object.entries(greaterThanMemoryMap).reduce((prev, current) =>
                        prev[1] > current[1] ? prev : current
                    );
                    result = parseFloat(majorityGreaterScore[0]);
                }
                else if (lessThanCount >= 3) {
                    // Case 2: Majority rule on the lesser side of M.
                    const majorityLessScore = Object.entries(lessThanMemoryMap).reduce((prev, current) =>
                        prev[1] > current[1] ? prev : current
                    );
                    result = parseFloat(majorityLessScore[0]);
                }
                else {
                    // If none of the above applies, default to M.
                    result = memoryValue;
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

    getFloatValue(targetName) {
        const targetArray = this[`${targetName}Targets`];
        if (!targetArray || !targetArray.length) {
            return 0;
        }
        const selectedRadio = targetArray.find(el => el.checked);
        return selectedRadio ? parseFloat(selectedRadio.value) : 0;
    }
}
