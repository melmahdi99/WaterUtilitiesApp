import { Button, Card, CardActions, CardContent, CardMedia, Typography } from '@mui/material';
import { useBillings } from './useBillings';
import { NavLink, useNavigate, useParams } from 'react-router';

function BillingDetails() {

  const navigate = useNavigate();
  const {id} = useParams();
  const {billing} = useBillings(id);

  return (
    <Card>
        <CardMedia 
        component = 'img'
        src = {`/images/Test.png`} 
        />
        {/*use ${billing.category} for dynamic image*/}

        <CardContent>
            <Typography variant='h4'>ID: {billing?.id}</Typography>
            <Typography>{billing?.priceRate}</Typography>
            <Typography>{billing?.totalAmountDue}</Typography>
            <Typography>{billing?.dueDate}</Typography>
            <Typography>{billing?.totalAmountDue}</Typography>
            <Typography>{billing?.timePaid}</Typography>
            <Typography>{billing?.isPaid}</Typography>
            <Typography>{billing?.customerId}</Typography>
            <Typography>{billing?.waterMeterId}</Typography>

            </CardContent>
            <CardActions>
                <Button color="primary">Edit</Button>
                <Button component={NavLink} to={`/billings/manage/${id}`} color = "primary">Edit</Button>
                <Button onClick={() => navigate('/billings/')}>Cancel</Button>
            </CardActions>
    </Card>
  )
}

export default BillingDetails
