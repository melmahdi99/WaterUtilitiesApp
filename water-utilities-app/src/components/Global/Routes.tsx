import { createBrowserRouter } from "react-router";
import App from "./App";
import Welcome from "./Welcome";
import LoginForm from "./LoginForm";
import RequireAuth from "./RequireAuth";
import BuildingDashboard from "../Buildings/BuildingDashboard";
import BuildingDetails from "../Buildings/BuildingDetails";
import BuildingForm from "../Buildings/BuildingForm";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {element: <RequireAuth/>, children: [
            ]},
            {path: '', element: <Welcome/>},
            {path: 'login', element: <LoginForm/>},
            {path: 'buildings', element: <BuildingDashboard/>},
            {path: 'buildings/:id', element: <BuildingDetails/>},
            {path: 'buildings/create', element: <BuildingForm/>},
            {path: 'buildings/manage/:id', element: <BuildingForm/>}
        ]
    }
])