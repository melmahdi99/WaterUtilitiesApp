import { Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { useWaterTreatmentPlants } from './useWaterTreatmentPlants';
import { NavLink, useNavigate, useParams } from 'react-router';

function ActivityDetails() {

    const navigate = useNavigate();
    const {id} = useParams();
    const {waterTreatmentPlant} = useWaterTreatmentPlants(id);
    const address = `${waterTreatmentPlant?.streetNum} ${waterTreatmentPlant?.streetName} ${waterTreatmentPlant?.streetSuffix}, ${waterTreatmentPlant?.zipCode}`;


  return (
    <Card>
        {/* <CardMedia component='img' src={`/images/${activity.category}.png`}/> */}
        {/* <CardMedia component='img' src={`/images/Test.png`}/> */}
        <CardContent>
            <Typography variant='h4'>{address}</Typography>
            <Typography>Capacity: {waterTreatmentPlant?.waterVolumeCapacity} Gallons/Day</Typography>
            <Typography variant='subtitle1'>Street: {waterTreatmentPlant?.streetName}</Typography>
            <Typography>Street Suffix: {waterTreatmentPlant?.streetSuffix}</Typography>
            <Typography>ZipCode: {waterTreatmentPlant?.zipCode}</Typography>
            <Typography>Kingdom: {waterTreatmentPlant?.kingdomName}</Typography>
            <Typography>Lat: {waterTreatmentPlant?.lat}</Typography>
            <Typography>Long: {waterTreatmentPlant?.long}</Typography>
        </CardContent>
        <CardActions>
            <Button component={NavLink} to={`/waterTreatmentPlants/manage/${id}`} color="primary">Edit</Button>
            <Button onClick={() => navigate('/waterTreatmentPlants')}>Cancel</Button>
        </CardActions>
    </Card>
  )
}

export default ActivityDetails