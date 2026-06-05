import { Grid, Typography } from "@mui/material";
import MeterCard from './MeterCard'
import { useWaterMeters } from './useWaterMeters';

function MetersList() {
    const { waterMeters } = useWaterMeters();

    if (!waterMeters) return <Typography> Water meters loading...</Typography>

    return (
        <Grid container spacing={2}>
            {waterMeters.map(m => {
                return (
                    <MeterCard key={m.id} meter={m} />
                )
            })}
        </Grid>
    )
}

export default MetersList