import React from 'react';
import { PageTitle } from './page-title';

export const  Page = ({ title, children }) => (
  <div>
    {title && <PageTitle>{title}</PageTitle>}
    {children}
  </div>
);
