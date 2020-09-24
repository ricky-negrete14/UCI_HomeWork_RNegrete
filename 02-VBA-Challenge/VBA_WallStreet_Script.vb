Sub VBA_WallStreet():

    'Setting a cycle to loop through sheets in workbook
    Dim ws As Worksheet

    'Looping has begun with the variable set from above
    For Each ws In Worksheets

        'Columns Creation for Tickers, Yearly Changes, Percentage Changes, Total Stock Volume . . .
        ws.Cells(1, 9).Value = "Tickers"
        ws.Cells(1, 10).Value = "Yearly Changes"
        ws.Cells(1, 11).Value = "Percentage Changes"
        ws.Cells(1, 12).Value = "Total Stock Volume"

        'Setting Primary Variables
        Dim Ticker_ID As String
        Dim Total_Vol As Double
        Total_Vol = 0
        Dim Open_Amt As Double
        Open_Amt = 0
        Dim Close_Amt As Double
        Close_Amt = 0
        Dim Yearly_Changes As Double
        Yearly_Changes = 0
        Dim Percentage_Changes As Double
        Percentage_Changes = 0

        'Setting rowcount to count starting the second row of each spread sheet
        Dim rowcount As Long
        rowcount = 2

        'Setting in the lastrow for total looping of rows in Worksheet
        lastrow = ws.Cells(Rows.Count, 1).End(xlUp).Row

        'Searching for Ticker IDs
        For i = 2 To lastrow
            
            'Conditional to grab year open price
            If ws.Cells(i, 1).Value <> ws.Cells(i - 1, 1).Value Then

                Open_Amt = ws.Cells(i, 3).Value

            End If

            'Suming up the volumes of each row for yearly totals
            Total_Vol = Total_Vol + ws.Cells(i, 7)

            'Conditional to determine if the ticker symbol is changing
            If ws.Cells(i, 1).Value <> ws.Cells(i + 1, 1).Value Then

                'Moving Values to Columns
                ws.Cells(rowcount, 9).Value = ws.Cells(i, 1).Value
  
                ws.Cells(rowcount, 12).Value = Total_Vol

                'Calculate closing price
                Close_Amt = ws.Cells(i, 6).Value

                'Calculate the price change for the year
                Yearly_Changes = Close_Amt - Open_Amt
                ws.Cells(rowcount, 10).Value = Yearly_Changes

                'Conditional to format with color index for postive/negative changes
                If Yearly_Changes >= 0 Then
                    ws.Cells(rowcount, 10).Interior.ColorIndex = 4
                Else
                    ws.Cells(rowcount, 10).Interior.ColorIndex = 3
                End If

                'Conditional for calculating percent change
                If Open_Amt = 0 And Close_Amt = 0 Then
                    'Starting at zero and ending at zero will be a zero increase.  Cannot use a formula because
                    'it would be dividing by zero.
                    Percentage_Changes = 0
                    ws.Cells(rowcount, 11).Value = Percentage_Changes
                    ws.Cells(rowcount, 11).NumberFormat = "0.00%"
                ElseIf Open_Amt = 0 Then
                    'If a stock starts at zero and increases, it grows by infinite percent.
                    'Because of this, we only need to evaluate actual price increase by dollar amount and therefore put
                    '"New Stock" as percent change.
                    Dim Percentage_Changes_NA As String
                    Percentage_Changes_NA = "New Stock"
                    ws.Cells(rowcount, 11).Value = Percentage_Changes
                Else
                    Percentage_Changes = Yearly_Changes / Open_Amt
                    ws.Cells(rowcount, 11).Value = Percentage_Changes
                    ws.Cells(rowcount, 11).NumberFormat = "0.00%"
                End If

                'Add 1 to rowcount to move it to the next empty row in the summary table
                rowcount = rowcount + 1

                'Reset total stock volume, year open price, year close price, year change, year percent change
                Total_Vol = 0
                Open_Amt = 0
                Close_Amt = 0
                Yearly_Changes = 0
                Percentage_Changes = 0
                
            End If
        Next i

        'Create a best/worst performance table
        'Titles
        ws.Cells(2, 15).Value = "Greatest % Increase"
        ws.Cells(3, 15).Value = "Greatest % Decrease"
        ws.Cells(4, 15).Value = "Greatest Total Volume"
        ws.Cells(1, 16).Value = "Ticker"
        ws.Cells(1, 17).Value = "Value"

        'Assign lastrow to count the number of rows in the summary table
        lastrow = ws.Cells(Rows.Count, 9).End(xlUp).Row

        'Set variables to hold best performer, worst performer, and stock with the most volume
        Dim best_stock As String
        Dim best_value As Double

        'Set best performer equal to the first stock
        best_value = ws.Cells(2, 11).Value

        Dim worst_stock As String
        Dim worst_value As Double

        'Set worst performer equal to the first stock
        worst_value = ws.Cells(2, 11).Value

        Dim most_vol_stock As String
        Dim most_vol_value As Double

        'Set most volume equal to the first stock
        most_vol_value = ws.Cells(2, 12).Value

        'Loop to search through summary table
        For j = 2 To lastrow

            'Conditional to determine best performer
            If ws.Cells(j, 11).Value > best_value Then
                best_value = ws.Cells(j, 11).Value
                best_stock = ws.Cells(j, 9).Value
            End If

            'Conditional to determine worst performer
            If ws.Cells(j, 11).Value < worst_value Then
                worst_value = ws.Cells(j, 11).Value
                worst_stock = ws.Cells(j, 9).Value
            End If

            'Conditional to determine stock with the greatest volume traded
            If ws.Cells(j, 12).Value > most_vol_value Then
                most_vol_value = ws.Cells(j, 12).Value
                most_vol_stock = ws.Cells(j, 9).Value
            End If

        Next j

        'Move best performer, worst performer, and stock with the most volume items to the performance table
        ws.Cells(2, 16).Value = best_stock
        ws.Cells(2, 17).Value = best_value
        ws.Cells(2, 17).NumberFormat = "0.00%"
        ws.Cells(3, 16).Value = worst_stock
        ws.Cells(3, 17).Value = worst_value
        ws.Cells(3, 17).NumberFormat = "0.00%"
        ws.Cells(4, 16).Value = most_vol_stock
        ws.Cells(4, 17).Value = most_vol_value

        'Autofit table columns
        ws.Columns("I:L").EntireColumn.AutoFit
        ws.Columns("O:Q").EntireColumn.AutoFit

    Next ws

End Sub