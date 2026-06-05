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
import CustomerDashboard from "../Customers/CustomerDashboard";
import CustomerDetails from "../Customers/CustomerDetails";
import MetersList from "../WaterMeters/MeterList";
import BillingDashboard from "../Billings/BillingDashboard";
import BillingForm from "../Billings/BillingForm";
import BillingDetails from "../Billings/BillingDetails";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {element: <RequireAuth/>, children: [
                {path: 'createWaterTreatmentPlant', element: <WaterTreatmentPlantsForm/>},
                {path: 'waterTreatmentPlants/manage/:id', element: <WaterTreatmentPlantsForm/>},
                {path: 'customers/manage/:id', element: <CustomerDetails/>},
                {path: 'billings/manage/:id', element: <BillingForm/>},
                {path: 'billings/:id', element: <BillingDetails/>}
            ]},
            {path: 'accounts/user-info', element: <UserInfo/>},
            {path: '', element: <Welcome/>},
            {path: 'login', element: <LoginForm/>},
            {path: 'waterTreatmentPlants', element: <WaterTreatmentPlantsList/>},
            {path: 'waterTreatmentPlants/:id', element: <WaterTreatmentPlantDetails/>},
            {path: 'buildings', element: <BuildingDashboard/>},
            {path: 'buildings/:id', element: <BuildingDetails/>},
            {path: 'buildings/create', element: <BuildingForm/>},
            {path: 'buildings/manage/:id', element: <BuildingForm/>},
            {path: 'customers', element: <CustomerDashboard/>},
            {path: 'customers/:id', element: <CustomerDetails/>},
            {path: 'watermeters', element: <MetersList/>},
            {path: 'billings', element: <BillingDashboard/>},
            

        ]
    }
])