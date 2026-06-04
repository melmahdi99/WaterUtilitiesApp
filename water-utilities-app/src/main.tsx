import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Welcome from './components/Global/Welcome.tsx'
import LoginForm from './components/Global/LoginForm.tsx'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import {ReactQueryDevtools } from '@tanstack/react-query-devtools'
import { RouterProvider } from 'react-router';
import { router } from './components/Global/Routes.tsx';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <ReactQueryDevtools />  
      <RouterProvider router={router} />
    </QueryClientProvider>
  </StrictMode>,
)
