import React from 'react'
import { Grid } from '@mui/material';
import CustomerList from './CustomersList';


function CustomerDashboard() {


  return (
    <Grid container spacing={2} sx={{ m : 3 }}>

        <Grid size={8}>
           <CustomerList />
        </Grid>

    </Grid>
  )
}

export default CustomerDashboard