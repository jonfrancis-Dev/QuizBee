import { Box, CssBaseline, Typography, Container, Card, CardContent, CircularProgress, Alert, List, ListItem, ListItemText } from "@mui/material";
import NavBar from "./NavBar";
import { useQuiz } from "../../lib/hooks/useQuiz";

function App() {
  const { data: questions, isLoading, error } = useQuiz();

  return (
    <Box sx={{ bgcolor: '#f5f5f5', minHeight: '100vh' }}>
      <CssBaseline />
      <NavBar />

      <Container maxWidth="md" sx={{ mt: 4 }}>
        <Typography variant="h3" gutterBottom textAlign="center">
          QuizBee
        </Typography>

        {isLoading && (
          <Box textAlign="center" mt={4}>
            <CircularProgress />
          </Box>
        )}

        {error && (
          <Alert severity="error" sx={{ mt: 4 }}>
            Something went wrong!
          </Alert>
        )}

        {!isLoading && !error && questions?.map((q, index) => (
          <Card key={q.id} sx={{ mb: 3 }}>
            <CardContent>
              <Typography variant="h6">
                {index + 1}. {q.text}
              </Typography>
              {q.hint && (
                <Typography variant="body2" color="text.secondary" sx={{ mb: 1 }}>
                  Hint: {q.hint}
                </Typography>
              )}
              <List dense>
                {q.choices.map(choice => (
                  <ListItem key={choice.id}>
                    <ListItemText primary={choice.text} />
                  </ListItem>
                ))}
              </List>
            </CardContent>
          </Card>
        ))}
      </Container>
    </Box>
  );
}

export default App;
