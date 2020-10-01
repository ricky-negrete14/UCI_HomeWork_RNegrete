#Setting up source
import os
import csv

budget_data = os.path.join("..", "Resources", "budget_data.csv")

# Setting Variables
total_months = 0
months_cycled = []

total_revenue = 0
revenue = []
past_revenue = 0

revenue_change = 0
revenue_change_list = []
average_revenue = 0

max_increase = ["", 0]
max_decrease = ["", 9999999]



#open the csv file
with open('budget_data.csv') as csvfile:  
    csvreader = csv.reader(csvfile)

    #Loop through to find total months
    for row in csvreader:

        #totaling months
        total_months += 1

        #calculating Total $$$
        total_revenue = total_revenue + int(row["Profit/Losses"])

        #Calculating through cycled months 
        revenue_change = float(row["Profit/Losses"])- past_revenue
        past_revenue = float(row["Profit/Losses"])
        revenue_change_list = revenue_change_list + [revenue_change]
        months_cycled = [months_cycled] + [row["Date"]]
       

        # Calculating max decreases & increases
        if revenue_change>max_increase[1]:
            max_increase[1]= revenue_change
            max_increase[0] = row['Date']

        if revenue_change<max_decrease[1]:
            max_decrease[1]= revenue_change
            max_decrease[0] = row['Date']
    average_revenue = sum(revenue_change_list)/len(revenue_change_list)

#produce written file
text = "analysis.txt"

#write changes to csv
with open(text, 'w') as file:
    file.write("Financial Analysis\n")
    file.write("Total Months: %d\n" % total_months)
    file.write("Total Revenue: $(%d)\n" % total_revenue)
    file.write("Average Revenue Change $%d\n" % average_revenue)
    file.write("Greatest Increase in Revenue: %s ($%s)\n" % (max_increase[0], max_increase[1]))
    file.write("Greatest Decrease in Revenue: %s ($%s)\n" % (max_decrease[0], max_decrease[1]))