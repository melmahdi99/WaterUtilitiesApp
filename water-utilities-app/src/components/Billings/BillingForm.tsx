import { Button, Stack, TextField, Typography } from '@mui/material'
import React from 'react'
import type { Billing } from '../../types/billing';
import { useBillings } from './useBillings';
import { NavLink, useNavigate, useParams } from 'react-router';


function BillingForm() {

    const navigate = useNavigate();
    const {id} = useParams();

    const {createBilling, updateBilling, billing, isLoadingBilling} = useBillings(id);

    async function handleSubmit(event: React.SubmitEvent){
            event.preventDefault();
            
            const formData = new FormData(event.target);
            const data: Record<string, unknown> = {}
            formData.forEach((value, key) => {
                data[key] = value;
            });

            if(billing) {
                data.id = billing.id;
                await updateBilling.mutateAsync(data as unknown as Billing);
                // axios request to put the new version of the record
                navigate(`/billings/${billing.id}`)
            } else {
                createBilling.mutate(data as unknown as Billing, {
                    onSuccess: (billing) => {
                        navigate(`/billings/${billing.id}`)
                    }
                });


              
                
            }
    }

if(isLoadingBilling) return <Typography>Loading billing...</Typography>

  return (
    <Stack
    component='form' 
    onSubmit={handleSubmit}>
    direction ={'column'}
    spacing={1}

        <Typography variant='h5'>{billing ? 'Edit Billing' : 'CreateBilling'} </Typography>

        <TextField
        label = "PriceRate"
        name="priceRate"
        defaultValue={billing?.priceRate}
        />

        <TextField
        label = "TotalAmountDue"
        name="totalAmountDue"
        defaultValue={billing?.totalAmountDue}
        />

        <TextField
        label = "DueDate"
        name="dueDate"
        defaultValue={billing?.dueDate}
        />

        <TextField
        label = "TimePaid"
        name="timePaid"
        defaultValue={billing?.timePaid}
        />

        <TextField
        label = "IsPaid"
        name="isPaid"
        defaultValue={billing?.isPaid}
        />

        <TextField
        label = "CustomerId"
        name="customerId"
        defaultValue={billing?.customerId}
        />

        <TextField
        label = "WaterMeterId"
        name="waterMeterId"
        defaultValue={billing?.waterMeterId}
        />

        <Button type="submit" variant='contained'>
            Submit
        </Button>
        {billing && <Button component={NavLink} to={`/billings/${billing.id}`}>Cancel</Button>}

    </Stack>
  )
}

export default BillingForm