import { Box, CssBaseline } from "@mui/material";
import NavBar from "./NavBar";
import QuizPage from "../../features/quiz/QuizPage";

function App() {

  return (
    <Box sx={{ bgcolor: '#f5f5f5', minHeight: '100vh' }}>
      <CssBaseline />
      <NavBar />
      <QuizPage/>
    </Box>
  );
}

export default App;
