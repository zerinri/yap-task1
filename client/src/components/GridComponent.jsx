import {
  Grid,
  Card,
  CardActionArea,
  CardContent,
  Typography,
} from "@mui/material";
import React from "react";

function GridComponent({ name,defaultObject }) {
  return (
    <Grid item md={3} xs={6}>
      <Card>
        <CardActionArea href={`${defaultObject.hrefLocation}${name}`}>
          <CardContent>
            <Typography>{name}</Typography>
          </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
}

export default GridComponent;
