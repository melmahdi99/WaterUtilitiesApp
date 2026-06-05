import { createBrowserRouter } from "react-router";
import App from "./App";
import Welcome from "./Welcome";
import LoginForm from "./LoginForm";
import RequireAuth from "./RequireAuth";
import BuildingDashboard from "../Buildings/BuildingDashboard";
import BuildingDetails from "../Buildings/BuildingDetails";
import BuildingForm from "../Buildings/BuildingForm";
import WaterTreatmentPlantsList from "../WaterTreatmentPlants/WaterTreatmentPlantsList";
import WaterTreatmentPlantsForm from "../WaterTreatmentPlants/WaterTreatmentPlantsForm"
import WaterTreatmentPlantDetails from '../WaterTreatmentPlants/WaterTreatmentPlantDetails'
import UserInfo from "./UserInfo";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {element: <RequireAuth/>, children: [
                {path: 'createWaterTreatmentPlant', element: <WaterTreatmentPlantsForm/>},
                {path: 'waterTreatmentPlants/manage/:id', element: <WaterTreatmentPlantsForm/>},
            ]},
            {path: 'accounts/user-info', element: <UserInfo/>},
            {path: '', element: <Welcome/>},
            {path: 'login', element: <LoginForm/>},
            {path: 'waterTreatmentPlants', element: <WaterTreatmentPlantsList/>},
            {path: 'waterTreatmentPlants/:id', element: <WaterTreatmentPlantDetails/>},
            {path: 'buildings', element: <BuildingDashboard/>},
            {path: 'buildings/:id', element: <BuildingDetails/>},
            {path: 'buildings/create', element: <BuildingForm/>},
            {path: 'buildings/manage/:id', element: <BuildingForm/>}
        ]
    }
])