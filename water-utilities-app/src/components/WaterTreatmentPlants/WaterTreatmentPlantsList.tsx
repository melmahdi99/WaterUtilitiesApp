import { Grid, Typography } from "@mui/material";
import WaterTreatmentPlantCard from "./WaterTreatmentPlantCard";
import { useWaterTreatmentPlants } from "./useWaterTreatmentPlants";

function WaterTreatmentPlantsList() {
    const {waterTreatmentPlants} = useWaterTreatmentPlants();
    if (!waterTreatmentPlants) return <Typography>Loading Water Treatment Plants...</Typography>

    return(
        <>
        <Grid container spacing={2}>
            {waterTreatmentPlants.map(a =>{
                return(
                    <WaterTreatmentPlantCard key = {a.id} waterTreatmentPlant ={a}/>
                )
            })}
        </Grid>
        </>
    )



}

export default WaterTreatmentPlantsList;