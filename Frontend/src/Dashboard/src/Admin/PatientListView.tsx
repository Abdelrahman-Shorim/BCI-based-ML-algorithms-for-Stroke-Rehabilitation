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
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';


interface Column {
  id: 'PatientName' | 'PhoneNumber' | 'DoctorAssignedTo'|'Email';
  label: string;
  minWidth?: number;
  align?: 'right';
  format?: (value: number) => string;
}

const columns: readonly Column[] = [
  { id: 'PatientName', label: 'PatientName', minWidth: 170 },
  { id: 'PhoneNumber', label: 'PhoneNumber', minWidth: 100 },
  {
    id: 'DoctorAssignedTo',
    label: 'DoctorAssignedTo',
    minWidth: 170,
    align: 'right',
  },
  {id:'Email',label:'Email'},
 
];

interface Data {
  id: number;
  PatientName: string;
  PhoneNumber: string;
  DoctorAssignedTo: string;
  Email:string
}

function createData(
  id: number,
  PatientName: string,
  PhoneNumber: string,
  DoctorAssignedTo: string,
  Email:string,
): Data {
  return { id, PatientName,PhoneNumber, DoctorAssignedTo,Email};
}

const rows = [
  createData(1, 'Habiba Mohamed',  '0123456789','Dr.Mina','Mina@gmail.com'),
  createData(2, 'Youssef Ali',  '0123456789','Dr.Walaa','Youssef@gmail.com'),
  createData(3, 'Mohamed Wael',  '0123456789','Dr.Youssef','Mohamed@gmail.com'),
  createData(4, 'Mai Mourad',  '0123456789','Dr.Ali','Mai@gmail.com'),
  createData(5, 'Wael Gaser',  '0123456789','Dr.Mai','Wael@gmail.com'),
  createData(6, 'Safwat Ali',  '0123456789','Dr.Habiba','Safwat@gmail.com'),
  createData(7, 'Reem Nabil',  '0123456789','Dr.Abdelrahman','Reem@gmail.com'),
  createData(8, 'Tamer Alaa',  '0123456789','Dr.Ahmed','Tamer@gmail.com'),
  createData(9, 'Hazem Waleed',  '0123456789','Dr.Mina','Hazem@gmail.com'),
];

export default function PatientListView() {
    
    
 
 
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
              {columns.map((column) => { 
                return(
                <TableCell
                  key={column.id}
                  align={column.align}
                  style={{ minWidth: column.minWidth, backgroundColor: '#232933', color: '#FFFF' }}
                >
                  {column.label}
                </TableCell>
              )})}
              
              <TableCell style={{ minWidth: 170, backgroundColor: '#232933', color: '#FFFF' }}>Actions</TableCell>
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
                     
                      const value = row[column.id];
                      return (
                        <TableCell key={column.id} align={column.align} style={{ color: 'white' }}>
                          {column.format && typeof value === 'number'
                            ? column.format(value)
                            : value}
                        </TableCell>
                      );
              })}
                    <TableCell style={{ color: 'white' ,cursor: 'pointer'}}>
                    <DeleteIcon/>
                    <EditIcon/>
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
