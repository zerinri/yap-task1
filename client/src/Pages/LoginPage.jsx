import React, { Fragment, useState } from "react";
import "./LoginPageStyle.js";
import { Card, TextField, Grid, Typography, Button } from "@mui/material";
import { loginGrid, loginCard, loginButton } from "./LoginPageStyle.js";

function LoginPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const onSubmit = (event) => {
    event.preventDefault();
    console.log(username, password);
  };

  return (
    <Fragment>
      <Grid sx={loginGrid} container>
        <Card sx={loginCard}>
          <Typography variant="h2">Login</Typography>{" "}
          <Typography variant="h6">Username</Typography>
          <form onSubmit={onSubmit}>
            <TextField
              required
              label="Required"
              onChange={(e) => setUsername(e.target.value)}
            />
            <br />
            <Typography variant="h6">Password</Typography>
            <TextField
              type="password"
              className="loginTextField"
              required
              label="Required"
              onChange={(e) => setPassword(e.target.value)}
            />
            <br />
            <Button
              sx={loginButton}
              color="primary"
              variant="contained"
              type="submit"
            >
              Login
            </Button>
          </form>
        </Card>
      </Grid>
    </Fragment>
  );
}

export default LoginPage;
