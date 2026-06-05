import { Grid, Typography } from '@mui/material';
import BillingCard from './BillingCard';
import { useBillings } from './useBillings';


function BillingsList() {
    
    const {billings} = useBillings();

    if(!billings) return <Typography>Billings loading...</Typography>

    return (
        <>
        <Grid container spacing={2}>
            {billings.map(a => {
                return ( 
                <BillingCard key={a.id} billing={a} />
                )
            })}
        </Grid>
        </>
    )
}

export default BillingsList
