import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Welcome from './components/Global/Welcome.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Welcome />
  </StrictMode>,
)
