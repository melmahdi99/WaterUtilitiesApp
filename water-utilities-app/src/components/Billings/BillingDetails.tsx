import { Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { useBillings } from './useBillings';
import { NavLink, useNavigate, useParams } from 'react-router';

function BillingDetails() {

  const navigate = useNavigate();
  const {id} = useParams();
  const {billing} = useBillings(id);

  return (
    <Card>
        {/* <CardMedia 
        component = 'img'
      // src = {`/images/Test.png`} 
        />
        use ${billing.category} for dynamic image */}

        <CardContent>
            <Typography variant='h4'>Billing ID: {billing?.id}</Typography>
            <Typography>Price Rate: {billing?.priceRate}</Typography>
            <Typography>Total Amount Due: {billing?.totalAmountDue}</Typography>
            <Typography>Due Date: {billing?.dueDate}</Typography>
            <Typography>Time Paid: {billing?.timePaid}</Typography>
            <Typography>Is Paid: {billing?.isPaid}</Typography>
            <Typography>Customer ID: {billing?.customerId}</Typography>
            <Typography>Water Meter ID:{billing?.waterMeterId}</Typography>

            </CardContent>
            <CardActions>
                <Button component={NavLink} to={`/billings/manage/${id}`} color = "primary">Edit</Button>
                <Button onClick={() => navigate('/billings/')}>Cancel</Button>
            </CardActions>
    </Card>
  )
}

export default BillingDetails
