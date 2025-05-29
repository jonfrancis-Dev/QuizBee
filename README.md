# QuizBee

QuizBee is a full-stack quiz application built with React, TypeScript, and ASP.NET Core. It allows users to take a quiz consisting of randomly selected single and multiple-choice questions. Submissions are limited to one per user, verified via email address.

---

## Features

* Clean, responsive UI with Material UI
* Supports both single and multiple-choice answers
* Randomized questions and answer order
* Email input required for submission
* Prevents duplicate submissions by email
* Score and percentage calculation

---

## Tech Stack

### Frontend

* React + Vite
* TypeScript
* Material UI
* React Query
* Axios

### Backend

* ASP.NET Core Web API (.NET 9)
* Entity Framework Core
* SQLite (for development/prototype)

---

## Setup Instructions

### Backend

```bash
cd API

dotnet build

dotnet ef database update

dotnet run
```

### Frontend

```bash
cd client

npm install

npm run dev
```

---

## API Endpoints

| Method | Endpoint         | Description                      |
| ------ | ---------------- | -------------------------------- |
| GET    | /api/quiz        | Returns 10 random quiz questions |
| POST   | /api/quiz/submit | Submits user's answers           |

---

## Submission Rules

* All questions must be answered before submitting
* A valid email address is required
* Only one submission is allowed per user (email-locked)
* Questions with multiple correct answers must be fully correct to receive points

---

## Development Notes

* You can seed the database in `DbInitializer.cs`.
* The backend validates uniqueness of submissions based on `UserEmail`.
* Email validity is checked on the frontend and backend.
* For styling and layout, Material UI components are used throughout the app.
