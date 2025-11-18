// tailwind.config.js
// https://tailwindcss.com/docs/configuration
// https://tailwindcss.com/docs/theme

module.exports = {
  content: [
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml'
  ],
  safelist: [
    // Styles found in tag helpers
    // Base layout & sizing
    'block',
    'w-full',
    'max-w-lg',
    'sm:max-w-xs',
    'mt-1',
    'mt-4',
    'space-y-2',
    'relative',
    'flex',
    'items-start',
    'items-center',
    'h-4',
    'ml-3',
    'inline-flex',
    'rounded-md',
    'rounded-full',
    'px-2.5',
    'py-0.5',

    // Borders & shadows
    'border-gray-400',
    'shadow-sm',
    'disabled:border-slate-200',
    'disabled:shadow-none',

    // Focus states
    'focus:border-indigo-500',
    'focus:ring-indigo-500',
    'focus:ring-indigo-600',

    // Typography
    'text-base',
    'text-sm',
    'text-xs',
    'text-gray-900',
    'text-gray-400',
    'text-gray-600',
    'text-indigo-600',
    'text-indigo-700',
    'text-red-600',
    'text-yellow-600',
    'font-semibold',
    'font-medium',
    'leading-6',
    'underline',

    // Backgrounds
    'bg-gray-100',
    'disabled:bg-slate-50',

    // Placeholder
    'placeholder:text-gray-400',

    // Disabled
    'disabled:text-slate-500',

    // Interactive
    'hover:text-indigo-600'
  ],
  theme: {
    extend: {
      colors: {
        clifford: '#da373d',
      }
    }
  }
}
