import { Grid, Typography } from '@mui/material';
import CustomerCard from './CustomerCard';
import { useCustomer } from './useCustomer';

function CustomersList() {

    const {customers} = useCustomer();
    if(!customers) return <Typography>Customers loading...</Typography>
  
    return (
        <>
        <Grid container spacing={2}>
            {customers.map(c => {
                return (
                <CustomerCard key={c.id} customer={c}/>
                )
            })}
        </Grid>
        </>
    )
}


export default CustomersList