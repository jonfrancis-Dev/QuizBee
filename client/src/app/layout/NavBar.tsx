import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { Bolt } from '@mui/icons-material';

export default function NavBar() {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" sx={{backgroundImage:'linear-gradient(135deg, #182a73 0%, #218aae 69%, #20a7ac 89%)'}}>
                <Toolbar>
                    <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="menu"

                        sx={{
                            mr: 2,
                            display: { md: 'none' }
                        }}>
                        <MenuIcon />
                    </IconButton>

                    <Box sx={{ 
                        display:'flex', 
                        alignItems:'center', 
                        justifyContent:'center',
                        gap:1
                    }}>
                    <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                        QuizBee 
                    </Typography>
                    <Bolt />

                    </Box>
                    
                </Toolbar>
            </AppBar>
        </Box >
    );
}