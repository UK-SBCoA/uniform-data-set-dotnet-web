// tailwind.config.js
// https://tailwindcss.com/docs/configuration
// https://tailwindcss.com/docs/theme

module.exports = {
  content: [
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml'
  ],
  safelist: [
    'lg:grid-cols-2'
  ],
  theme: {
    extend: {
      colors: {
        clifford: '#da373d',
      }
    }
  }
}
