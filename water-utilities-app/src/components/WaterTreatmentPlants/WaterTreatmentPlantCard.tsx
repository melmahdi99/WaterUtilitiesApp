import React from 'react'
import { WaterTreatmentPlant } from '../../types'
import { Button, Card, CardActions, CardContent, Chip, Typography } from '@mui/material';
import { useWaterTreatmentPlants } from './useWaterTreatmentPlants';
import { useNavigate } from 'react-router';

type Props = {
    waterTreatmentPlant: WaterTreatmentPlant;
}

function WaterTreatmentPlantCard({waterTreatmentPlant} : Props) {

    const navigate = useNavigate();
    const {deleteWaterTreatmentPlant} = useWaterTreatmentPlants();

  return (
    <Card>
        <CardContent>
            <Typography>{waterTreatmentPlant.title}</Typography>
            <Typography>{waterTreatmentPlant.id}</Typography>
        </CardContent>
        <CardActions>
            <Chip label = {waterTreatmentPlant.category} variant='outlined'/>
            <Button onClick={() => navigate(`/waterTreatmentPlants/${waterTreatmentPlant.id}`)}>View</Button>
            <Button onClick={() => deleteWaterTreatmentPlant.mutateAsync(waterTreatmentPlant.id)} color='error'>Delete</Button>
        </CardActions>
    </Card>
  )
}

export default WaterTreatmentPlantCard