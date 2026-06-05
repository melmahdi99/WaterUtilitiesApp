import { Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { useWaterTreatmentPlants } from './useWaterTreatmentPlants';
import { NavLink, useNavigate, useParams } from 'react-router';
import { useAccount } from '../Global/useAccount';

function WaterTreatmentPlantDetails() {

    const navigate = useNavigate();
    const {id} = useParams();
    const {currentUser} = useAccount();
    const {waterTreatmentPlant} = useWaterTreatmentPlants(id);
    const address = `${waterTreatmentPlant?.streetNum} ${waterTreatmentPlant?.streetName} ${waterTreatmentPlant?.streetSuffix}, ${waterTreatmentPlant?.zipCode}`;


  return (
    <Card>
        {/* <CardMedia component='img' src={`/images/${activity.category}.png`}/> */}
        {/* <CardMedia component='img' src={`/images/Test.png`}/> */}
        <CardContent>
            <Typography variant='h4'>{address}</Typography>
            <Typography>Capacity: {waterTreatmentPlant?.waterVolumeCapacity} Gallons/Day</Typography>
            <Typography>Turbidity: {waterTreatmentPlant?.turbidity}</Typography>
            <Typography variant='subtitle1'>Street: {waterTreatmentPlant?.streetName}</Typography>
            <Typography>Street Suffix: {waterTreatmentPlant?.streetSuffix}</Typography>
            <Typography>ZipCode: {waterTreatmentPlant?.zipCode}</Typography>
            <Typography>Kingdom: {waterTreatmentPlant?.kingdomName}</Typography>
            <Typography>Lat: {waterTreatmentPlant?.latitude}</Typography>
            <Typography>Long: {waterTreatmentPlant?.longitude}</Typography>
        </CardContent>
        <CardActions>
            {currentUser?.role == 'Admin' && <Button component={NavLink} to={`/waterTreatmentPlants/manage/${id}`} color="primary">Edit</Button>}
            <Button onClick={() => navigate('/waterTreatmentPlants')}>Cancel</Button>
        </CardActions>
    </Card>
  )
}

export default WaterTreatmentPlantDetails