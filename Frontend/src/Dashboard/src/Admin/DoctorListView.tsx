import * as React from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import './DoctorList.css';
import { useNavigate } from 'react-router-dom';

import MoreHorizIcon from '@mui/icons-material/MoreHoriz';


interface Column {
  id: 'DoctorName' | 'Status' | 'PatientsSupervising'|'PhoneNumber'|'Email';
  label: string;
  minWidth?: number;
  align?: 'right';
  format?: (value: number) => string;
}

const columns: readonly Column[] = [
  { id: 'DoctorName', label: 'DoctorName', minWidth: 170 },
  { id: 'Status', label: 'Status', minWidth: 100 },
  {
    id: 'PatientsSupervising',
    label: 'Patients Supervising no.',
    minWidth: 170,
    align: 'right',
  },
  {id:'PhoneNumber',label:'PhoneNumber'},
  {id:'Email',label:'Email'},
];

interface Data {
  id: number;
  DoctorName: string;
  Status: string;
  PatientsSupervising: number;
  PhoneNumber:string;
  Email:string
}

function createData(
  id: number,
  DoctorName: string,
  Status: string,
  PatientsSupervising: number,
  PhoneNumber:string,
  Email:string,
): Data {
  return { id, DoctorName, Status, PatientsSupervising,PhoneNumber,Email};
}

const rows = [
  createData(1, 'Dr.Mina', 'Available', 10,'0123456789','Mina@gmail.com'),
  createData(2, 'Dr.Mai', 'Available', 7,'0123456789','Mai@gmail.com'),
  createData(3, 'Dr.Youssef', 'Available', 14,'0123456789','Youssef@gmail.com'),
  createData(4, 'Dr.Walaa', 'Available', 15,'0123456789','Walaa@gmail.com'),
  createData(5, 'Dr.Peter', 'Available', 16,'0123456789','Peter@gmail.com'),
  createData(6, 'Dr.Mona', 'Available', 18,'0123456789','Mona@gmail.com'),
  createData(7, 'Dr.Shawqy', 'Not Available', 20,'0123456789','Shawqy@gmail.com'),
  createData(8, 'Dr.Medhat', 'Available', 25,'0123456789','Medhat@gmail.com'),
  createData(9, 'Dr.Dina', 'Available', 9,'0123456789','Dina@gmail.com'),
  createData(10, 'Dr.Merihan', 'Not Available', 5,'0123456789','Merihan@gmail.com'),
  createData(11, 'Dr.Samir', 'Available', 12,'0123456789','Samir@gmail.com'),
  createData(12, 'Dr.Lina', 'Available', 7,'0123456789','Lina@gmail.com'),
  createData(13, 'Dr.Mohamed', 'Available', 8,'0123456789','Mohamed@gmail.com'),
  createData(14, 'Dr.Ahmed', 'Not Available', 14,'0123456789','Ahmed@gmail.com'),
];

export default function DoctorListView() {
  const navigate = useNavigate();

  const handleCellClick = (row: Data) => {
    console.log(row);
    // Navigate to DoctorDetails page and pass rowData as state
    navigate('/DoctorDetails', { state: { doctor: row as Data } });
  };

  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(10);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>,
  ) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  return (
    <Paper sx={{ width: '100%', overflow: 'hidden', backgroundColor: 'rgb(4,12,24)', color: 'white' }}>
      <TableContainer sx={{ maxHeight: 440 }}>
        <Table stickyHeader aria-label="sticky table">
          <TableHead>
            <TableRow>
              {columns.map((column) => { if(column.id!='PhoneNumber'&&column.id!='Email'){
                return(
                <TableCell
                  key={column.id}
                  align={column.align}
                  style={{ minWidth: column.minWidth, backgroundColor: '#232933', color: '#FFFF' }}
                >
                  {column.label}
                </TableCell>
              )}})}
              
              <TableCell style={{ minWidth: 170, backgroundColor: '#232933', color: '#FFFF' }}>View</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((row) => {
                return (
                  <TableRow
                    hover
                    role="checkbox"
                    tabIndex={-1}
                    key={row.id}
                  >
                    {columns.map((column) => {
                      if (column.id !== 'PhoneNumber' && column.id !== 'Email') {
                      const value = row[column.id];
                      return (
                        <TableCell key={column.id} align={column.align} style={{ color: 'white' }}>
                          {column.format && typeof value === 'number'
                            ? column.format(value)
                            : value}
                        </TableCell>
                      );
              }})}
                    <TableCell style={{ color: 'white' ,cursor: 'pointer'}}>
                      <MoreHorizIcon onClick={() => handleCellClick(row)} />
                    </TableCell>
                  </TableRow>
                );
                  
              })}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        rowsPerPageOptions={[10, 25, 100]}
        component="div"
        count={rows.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
        sx={{ backgroundColor: '#232933', color: '#FFFF' }}
      />
    </Paper>
  );
}
