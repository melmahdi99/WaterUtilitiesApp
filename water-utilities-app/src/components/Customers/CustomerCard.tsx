import React from 'react'
import type { Customer } from '../../types/Customer';
import { Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { useCustomer } from './useCustomer';
import { useNavigate } from 'react-router';

type Props = {
    customer: Customer;
}

function CustomerCard({customer} : Props) {

    const navigate = useNavigate()
    const {deleteCustomer} = useCustomer();

  return (
    <Card>
        <CardContent>
            <Typography>{customer.firstName} {customer.lastName}</Typography>
        </CardContent>
        <CardActions>
            <Button onClick={() => navigate(`/customers/${customer.id}`)}>View</Button>
            <Button onClick={() => deleteCustomer.mutateAsync(customer.id)} color='error'>Delete</Button>
        </CardActions>
    </Card>
  )
}

export default CustomerCard