import { Grid, Typography } from "@mui/material";
import WaterTreatmentPlantCard from "./WaterTreatmentPlantCard";
import { useWaterTreatmentPlants } from "./useWaterTreatmentPlants";

function WaterTreatmentPlantsList() {
    const {wtpList} = useWaterTreatmentPlants();
    if (!wtpList) return <Typography>Loading Water Treatment Plants...</Typography>

    return(
        <>
        <Grid container spacing={2}>
            {wtpList.map(a =>{
                return(
                    <WaterTreatmentPlantCard key = {a.id} waterTreatmentPlant ={a}/>
                )
            })}
        </Grid>
        </>
    )



}

export default WaterTreatmentPlantsList;