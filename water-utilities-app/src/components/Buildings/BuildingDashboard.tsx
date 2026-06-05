import { Grid } from '@mui/material';
import BuildingsList from './BuildingsList.tsx';


function BuildingDashboard() {


    return (
        <Grid container spacing={2} sx={{ m: 3 }}>
            <Grid size={8}>
                <BuildingsList />
            </Grid>
            <Grid size={4}>
                placeholder
            </Grid>
        </Grid>
    );
}


export default BuildingDashboard;