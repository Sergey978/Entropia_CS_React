import React, { useEffect } from "react";
import "./table.css";
//import { IPoint, ITableRow } from "../../context/graph-context";
import { DataContext } from "../context";

export const TableComponent = () => {
  const graphContext = React.useContext(DataContext);
  const tableRef = React.useRef(null);
  const rowRef = React.useRef(null);

  const onClickTableHandle = (evt) => {
    evt.preventDefault();
    let rowIndex = parseInt(evt.currentTarget.id.substring(1));
    graphContext?.setScrollTo("point");
    graphContext.updateTable(rowIndex);
  };

  //scroll to selected row
  useEffect(() => {
    if (graphContext?.scrollTo === "table") {
      const selectedRowindex = graphContext?.table.find(
        (o) => o.IsSelected === true
      ).Quantity;

      const el = document.querySelector(`#r${selectedRowindex}`);
      if (el) el.scrollIntoView({ behavior: "smooth", block: "center" });
    }
  }, [graphContext?.table]);

  return (
    <table className="table table-bordered table-striped table-wrapper-scroll-y my-custom-scrollbar table-fixed">
      <thead>
        <tr>
          <th className="col-xs-3 text-center">Quantity</th>
          <th className="col-xs-3 text-center">Sell</th>
          <th className="col-xs-3 text-center">Profit</th>
          <th className="col-xs-3 text-center">Tax</th>
          <th className="col-xs-4 text-center">Markup</th>
        </tr>
      </thead>
      <tbody id="tbody">
        {graphContext?.table.map((row) => (
          <tr
            key={"row" + row.Quantity}
            id={"r" + row.Quantity}
            onClick={onClickTableHandle}
            className={row.IsSelected ? "display-5 " : ""}
            ref={row.IsSelected ? rowRef : null}
          >
            <td
              className={
                row.Profit > 0
                  ? "col-xs-3 text-center text-success"
                  : "col-xs-3 text-center text-danger"
              }
            >
              {row.Quantity}
            </td>
            <td
              className={
                row.Profit > 0
                  ? "col-xs-3 text-center text-success"
                  : "col-xs-3 text-center text-danger"
              }
            >
              {row.Price}
            </td>
            <td
              className={
                row.Profit > 0
                  ? "col-xs-3 text-center text-success"
                  : "col-xs-3 text-center text-danger"
              }
            >
              {row.Profit.toFixed(2)}
            </td>
            <td
              className={
                row.Profit > 0
                  ? "col-xs-3 text-center text-success"
                  : "col-xs-3 text-center text-danger"
              }
            >
              {row.Tax.toFixed(2)}
            </td>
            <td
              className={
                row.Profit > 0
                  ? "col-xs-3 text-center text-success"
                  : "col-xs-4 text-center text-danger"
              }
            >
              {row.Markup.toFixed(2)}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};
