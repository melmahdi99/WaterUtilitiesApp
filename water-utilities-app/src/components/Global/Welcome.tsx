// import { useLocation, useNavigate} from 'react-router'
import { Box, Typography } from "@mui/material"

function Welcome() {
    // const navigate = useNavigate();
    // const location = useLocation();
    return (
        <Box sx={{
                backgroundImage: 'url("https://cdn.wikimg.net/en/zeldawiki/images/thumb/b/bf/TotK_Lake_Mekar.png/1200px-TotK_Lake_Mekar.png")',
                backgroundPosition: 'center',
                backgroundRepeat: 'no-repeat',
                backgroundSize: '100%',
                backgroundColor: 'rgba(8, 0, 0, 0.1)',
                backgroundBlendMode: 'overlay',
                display:"flex",
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                minHeight: '100vh',
                padding: 2
            }}>
            <Typography variant="h2"
                sx={{
                    color: "white",
                    textShadow: '2px 3px rgba(78, 75, 75, 1)',
                    
            }}>Welcome to the Water Utilities & Billing App!</Typography>
            <Typography variant="h6"
                sx={{
                    color: "white",
                    textShadow: '2px 3px rgba(78, 75, 75, 0.6)',
            }}>To get started, click the login button on the top right.</Typography>
        </Box>
        
    )
}

export default Welcome