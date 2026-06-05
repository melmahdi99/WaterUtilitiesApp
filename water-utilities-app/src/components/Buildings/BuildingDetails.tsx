import { Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { NavLink, useNavigate, useParams } from 'react-router';
import { useBuildings } from './useBuildings.ts';


function BuildingDetails() {


    const navigate = useNavigate();
    const { id } = useParams();
    const { building } = useBuildings(id);


    return (
        <Card>
            <CardContent>
                <Typography variant='h4'>
                    {building?.streetNum} {building?.streetName} {building?.streetSuffix}
                </Typography>
                <Typography variant='subtitle1'>Kingdom: {building?.kingdomName}</Typography>
                <Typography>Type: {building?.buildingType}</Typography>
                <Typography>Zip Code: {building?.zipCode}</Typography>
                <Typography>Latitude: {building?.latitude}</Typography>
                <Typography>Longitude: {building?.longitude}</Typography>
            </CardContent>
            <CardActions>
                <Button component={NavLink} to={`/buildings/manage/${id}`} color='primary'>Edit</Button>
                <Button onClick={() => navigate('/buildings')}>Back</Button>
            </CardActions>
        </Card>
    );
}


export default BuildingDetails;