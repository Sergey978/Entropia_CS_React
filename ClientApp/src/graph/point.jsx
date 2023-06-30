import React, { Component, useEffect } from "react";
import "./graph.css";
import { DataContext } from "../context";

function isNumber(value) {
  return typeof value === "number" && isFinite(value);
}

export const Point = ({ tableRow, chartParams }) => {
  const graphContext = React.useContext(DataContext);

  let x = 100 + chartParams.oxn + (tableRow.Markup - 100) * chartParams.kx;
  let y = chartParams.oyn + chartParams.ly - tableRow.Profit * chartParams.ky;
  x = isNumber(x) ? x : 0;
  y = isNumber(y) ? y : 0;

  const onClickPointHandle = (evt) => {
    evt.preventDefault();
    let rowIndex = parseInt(evt.currentTarget.id);
    graphContext?.setScrollTo("table");
    graphContext.updateTable(rowIndex);
  };

  return (
    <div
      id={tableRow.Quantity.toString()}
      onClick={onClickPointHandle}
      data-toggle="tooltip"
      data-placement="top"
      title={
        "Quantity  " +
        tableRow.Quantity +
        "\n " +
        "Selling Price  " +
        tableRow.Price +
        "\n " +
        "Markup " +
        tableRow.Markup.toFixed(2) +
        "\n " +
        "Profit " +
        tableRow.Profit.toFixed(2)
      }
      className={tableRow.IsSelected ? "point-selected" : "point"}
      style={{
        left: x,
        top: y,
      }}
    ></div>
  );
};
