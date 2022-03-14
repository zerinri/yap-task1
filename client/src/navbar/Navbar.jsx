import React from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  Container,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import LogoutRoundedIcon from "@mui/icons-material/LogoutRounded";
import { containerStyle, iconStyle } from "./NavbarStyle";
import { Link } from "react-router-dom";

export default function Navbar() {

  return (
    <AppBar position="static">
      <Toolbar>
        <Link to="/categories">
          <IconButton edge="start">Yup-Task</IconButton>
        </Link>
        <Container sx={containerStyle}>
          <Link to="/addRecipe">
            <IconButton sx={iconStyle} href="">
              Add
              <AddIcon fontSize="small" />
            </IconButton>
          </Link>
          |
          <IconButton sx={iconStyle} href="/">
            Logout
            <LogoutRoundedIcon fontSize="small" />
          </IconButton>
        </Container>
      </Toolbar>
    </AppBar>
  );
}
