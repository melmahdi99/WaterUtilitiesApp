import { createBrowserRouter } from "react-router";
import App from "./App";
import Welcome from "./Welcome";
import LoginForm from "./LoginForm";
import RequireAuth from "./RequireAuth";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {element: <RequireAuth/>, children: [
            ]},
            {path: '', element: <Welcome/>},
            {path: 'login', element: <LoginForm/>}
            
        ]
    }
])