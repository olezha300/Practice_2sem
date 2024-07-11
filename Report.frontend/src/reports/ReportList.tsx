import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateReportDto, Client, ReportLookupDto } from '../api/api';
import { FormControl } from 'react-bootstrap';

const apiClient = new Client('http://localhost:5092');

async function createReport(report: CreateReportDto) {
    await apiClient.create('1.0', report);
    console.log('Report is created.');
}

const ReportList: FC<{}> = (): ReactElement => {
    let textInput = useRef(null);
    const [reports, setReports] = useState<ReportLookupDto[] | undefined>(undefined);

    async function getReports() {
        const reportListVm = await apiClient.getAll('1.0');
        setReports(reportListVm.reports);
    }

    useEffect(() => {
        setTimeout(getReports, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const report: CreateReportDto = {
                title: event.currentTarget.value,
            };
            createReport(report);
            event.currentTarget.value = '';
            setTimeout(getReports, 500);
        }
    };

    return (
        <div>
            Reports
            <div>
                <FormControl ref={textInput} onKeyPress={handleKeyPress} />
            </div>
            <section>
                {reports?.map((report) => (
                    <div>{report.title}</div>
                ))}
            </section>
        </div>
    );
};
export default ReportList;