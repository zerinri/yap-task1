import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { setCategory } from "../../redux/categories";
import Navbar from "../../navbar/Navbar";
import MainGridComponent from "../../components/MainGrid/MainGridComponent";

function CategoryListPage() {
  const categoryObject = {
    title: "Categories:",
    hrefLocation: "/categories/",
    viewTotalCost: false,
  };

  const person = [{ firstName: "Dorucak" }, { firstName: "Rucak" }];
  const [responseData, setResponseData] = useState([]);
  const dispatch = useDispatch();

  useEffect(() => {
    axios
      .get(`https://localhost:5001/api/Category/GetAllCategories`)
      .then((res) => {
        const allCategories = res.data.data;
        setResponseData(allCategories);
        dispatch(setCategory(allCategories));
      });
  }, [dispatch]);

  return (
    <Fragment>
      <Navbar />
      <MainGridComponent
        defaultObject={categoryObject}
        person={person}
        responseData={responseData}
      />
    </Fragment>
  );
}

export default CategoryListPage;
