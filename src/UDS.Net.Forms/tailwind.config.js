// tailwind.config.js
// https://tailwindcss.com/docs/configuration
// https://tailwindcss.com/docs/theme

module.exports = {
  content: [
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml'
  ],
  theme: {
    extend: {
      colors: {
        clifford: '#da373d',
      }
    }
  }
}
