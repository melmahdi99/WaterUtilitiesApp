import { Grid, Typography } from '@mui/material';
import BuildingCard from './BuildingCard';
import { useBuildings } from './useBuildings.ts';


function BuildingsList() {


    const { buildings } = useBuildings();


    if (!buildings) return <Typography>Buildings loading...</Typography>;


    return (
        <Grid container spacing={2}>
            {buildings.map(b => (
                <BuildingCard key={b.id} building={b} />
            ))}
        </Grid>
    );
}


export default BuildingsList;