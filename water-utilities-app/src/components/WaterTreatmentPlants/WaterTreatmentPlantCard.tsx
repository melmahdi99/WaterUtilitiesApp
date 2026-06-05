import React from 'react'
import type { WaterTreatmentPlant } from '../../types/watertreatmentplant'; 
import { Button, Card, Chip, CardActions, CardContent, Typography } from '@mui/material';
import { useWaterTreatmentPlants } from './useWaterTreatmentPlants';
import { useNavigate } from 'react-router';

type Props = {
    waterTreatmentPlant: WaterTreatmentPlant;
}

function WaterTreatmentPlantCard({waterTreatmentPlant} : Props) {

    const navigate = useNavigate();
    const {deleteWaterTreatmentPlant} = useWaterTreatmentPlants();
    const address = `${waterTreatmentPlant.streetNum} ${waterTreatmentPlant.streetName} ${waterTreatmentPlant.streetSuffix} ${waterTreatmentPlant.zipCode}`;

  return (
    <Card>
        <CardContent>
            <Typography sx={{fontWeight: 'bold'}}>{address}</Typography>
            <Typography>Capacity: {waterTreatmentPlant.waterVolumeCapacity}</Typography>
        </CardContent>
        <CardActions>
            <Chip label = {waterTreatmentPlant.kingdomName} variant='outlined'/>
            <Button onClick={() => navigate(`/waterTreatmentPlants/${waterTreatmentPlant.id}`)}>View</Button>
            <Button onClick={() => deleteWaterTreatmentPlant.mutateAsync(waterTreatmentPlant.id)} color='error'>Delete</Button>
        </CardActions>
    </Card>
  )
}

export default WaterTreatmentPlantCard