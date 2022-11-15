import React from "react";
import ReactElement from "react";

export const Grid = (chartProps) => {
  const lineStepX = chartProps.stepX * chartProps.kx;
  const lineStepY = chartProps.stepY * chartProps.ky;

  // vertical lines

  let xSlug = 0;
  const lines = [];
  // vertical lines

  for (var vLine = 100; vLine < chartProps.lx; vLine += lineStepX) {
    const x = chartProps.oxn + vLine;
    lines.push(
      <div
        className="vertical-line"
        key={"vLine" + vLine}
        style={{
          height: chartProps.ly,
          left: x,
          top: chartProps.oyn,
        }}
      />
    );
    // X slug
    lines.push(
      <div
        className="slug-x"
        key={"slug-x" + vLine}
        style={{
          left: x - 10,
          top: chartProps.oyn + chartProps.ly,
        }}
      >
        {100 + xSlug}{" "}
      </div>
    );
    xSlug += chartProps.stepX;
  }

  // horizontal lines
  let beginY = chartProps.oyn + chartProps.ly;
  let ySlug = 0;

  for (let hLine = 1; beginY - hLine * lineStepY > chartProps.oyn; hLine++) {
    const y = beginY - hLine * lineStepY;
    lines.push(
      <div
        className="horizontal-line"
        key={"hLine" + hLine}
        style={{
          width: chartProps.lx,
          top: y,
          left: chartProps.oxn,
        }}
      />
    );

    // slug on y axis
    ySlug += chartProps.stepY;
    lines.push(
      <div
        className="slug-y"
        key={"slug-y" + hLine}
        style={{
          left: chartProps.oxn - 40,
          top: y - 10,
        }}
      >
        {ySlug.toFixed(2)}{" "}
      </div>
    );
  }

  return <div>{lines}</div>;
};
