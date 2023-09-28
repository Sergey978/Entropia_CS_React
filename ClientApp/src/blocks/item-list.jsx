import React, { MouseEventHandler } from "react";
//import { IItem } from '../../services/data-service';
import "./item-list.css";

const ItemList = ({ data, onDelete, onHide, _deleted }) => (
  <table className="table table-hover shadow-inset rounded">
    <tbody>
      <tr>
        <th className="border-0" scope="col">
          Name
        </th>
        <th className="border-0" scope="col">
          Value
        </th>
        <th className="border-0" scope="col"></th>
      </tr>

      {data.map((item) => (
        <tr key={item.name}>
          <td
            key={item.name + "_1"}
            className={onHide && !item.selected ? "selected" : ""}
          >
            {item.name}
          </td>
          <td key={item.name + "_2"}>{item.price}</td>
          <td key={item.name + "_3"} className="items-button">
            {onDelete && (
              <button
                className="btn btn-sm  btn-outline-danger float-right"
                disabled={_deleted}
                onClick={() => {
                  onDelete(item.id);
                }}
              >
                <i className="far fa-lg fa-trash-alt"></i>
              </button>
            )}

            {onHide && (
              <button
                className="btn btn-sm  btn-outline-secondary float-right"
                onClick={() => {
                  onHide(item);
                }}
              >
                <i className="far fa-lg fa-eye-slash"></i>
              </button>
            )}
          </td>
        </tr>
      ))}
    </tbody>
  </table>
);

export { ItemList };
