import { Box, CssBaseline } from "@mui/material"
import NavBar from "./NavBar"

function App() {

  return (
    <>
      <Box sx={{ bgcolor: '#eeeeee', minHeight: '100vh' }}>
        <CssBaseline/> 
        <NavBar />
        Testing
      </Box>

    </>
  )
}

export default App
