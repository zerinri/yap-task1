import * as React from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  Container,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import LogoutRoundedIcon from "@mui/icons-material/LogoutRounded";
import { containerStyle, iconStyle } from "./NavbarStyle";

export default function Navbar() {
  return (
    <AppBar position="static">
      <Toolbar>
        <IconButton edge="start" href="/categories">
          Yup-Task
        </IconButton>
        <Container sx={containerStyle}>
          <IconButton sx={iconStyle}  href="/addRecipe">
            Add
            <AddIcon fontSize="small" />
          </IconButton>
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
