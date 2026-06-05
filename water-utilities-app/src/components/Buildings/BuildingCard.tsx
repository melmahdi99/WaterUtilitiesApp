import { Button, Card, CardActions, CardContent, Chip, Typography } from '@mui/material';
import { useNavigate } from 'react-router';
import { useBuildings } from './useBuildings.tsx';
import type { Building } from './building.d.ts';


type Props = {
    building: Building;
}


function BuildingCard({ building }: Props) {


    const navigate = useNavigate();
    const { deleteBuilding } = useBuildings();


    return (
        <Card>
            <CardContent>
                <Typography variant='h6'>{building.streetNum} {building.streetName} {building.streetSuffix}</Typography>
                <Typography variant='body2' color='text.secondary'>Zip: {building.zipCode}</Typography>
            </CardContent>
            <CardActions>
                <Chip label={building.kingdomName} variant='outlined' />
                <Chip label={building.buildingType} variant='outlined' />
                <Button onClick={() => navigate(`/buildings/${building.id}`)}>View</Button>
                <Button onClick={() => deleteBuilding.mutateAsync(building.id)} color='error'>Delete</Button>
            </CardActions>
        </Card>
    );
}


export default BuildingCard;