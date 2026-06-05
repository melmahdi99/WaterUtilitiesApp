import { Button, Checkbox, FormControlLabel, Stack, TextField, Typography } from '@mui/material'
import React from 'react'
import type { Customer } from '../../types/Customer';
import { useCustomer } from './useCustomer';
import { NavLink, useNavigate, useParams } from 'react-router';


function CustomerForm() {

  const navigate = useNavigate();
  const {id} = useParams();
  const {createCustomer, updateCustomer, customer, isLoadingCustomer} = useCustomer(id);

  async function handleSubmit(event: React.SubmitEvent){
    event.preventDefault();
    
    const formData = new FormData(event.target);
    const data: Record<string, unknown> = {}
    formData.forEach((value, key) => {
      data[key] = value;
    });

    // this forces data to populate with the 
    // value of the isCancelled checkbox
    data.isCancelled = formData.has('isCancelled');

    if(customer) {
      data.id = customer.id;
      await updateCustomer.mutateAsync(data as unknown as Customer);
      navigate(`/customers/${customer.id}`)
    } else {
      createCustomer.mutate(data as unknown as Customer, {
        onSuccess: (customer) => {
            navigate(`/customers/${customer.id}`)
        }
      });


    
    }

  }

  if(isLoadingCustomer) return <Typography>Loading customer...</Typography>

  return (
    <Stack
    component='form'
    onSubmit={handleSubmit}
    direction={'column'}
    spacing={1}
    >

        <Typography variant='h5'>{customer ? 'Edit Customer' : 'Create Customer'}</Typography>

        <TextField
        label="First Name"
        name="firstName"
        defaultValue={customer?.firstName}
        />

        <TextField
        label="Last Name"
        name="lastName"
        defaultValue={customer?.lastName}
        />


        <Button type="submit" variant='contained'>
            Submit
        </Button>
        {customer && <Button component={NavLink} to={`/customers/${customer.id}`}>Cancel</Button>}

    </Stack>
  )
}

export default CustomerForm