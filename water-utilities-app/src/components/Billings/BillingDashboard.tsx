import { Grid } from '@mui/material';
import BillingsList from './BillingsList';


function BillingDashboard() {
    
return (
    <Grid container spacing={2} sx={{ m : 3 }}>

        <Grid size={8}>
            <BillingsList />
        </Grid>

    </Grid>
    )
}

export default BillingDashboard
