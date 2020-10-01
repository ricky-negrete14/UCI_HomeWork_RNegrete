#Setting up source
import os
import csv

election_data = os.path.join("..", "Resources", "election_data.csv")

# Setting Variables
total_votes = 0
total_candidates = 0
winning_votes = 0
votes =["", 0]
candidate_votes = {}
candidates = []

with open("election_data.csv") as csvfile:
    reader = csv.reader(csvfile)

    for row in reader:
        total_votes += 1

        total_candidates = row["Candidate"]         

        if row["Candidate"] not in candidates:
            candidates.append(row["Candidate"])
            candidate_votes[row["Candidate"]] = 1
            
        else:
            candidate_votes[row["Candidate"]] = candidate_votes[row["Candidate"]] + 1

    # Winner Winner Chicken Dinner
    if (winning_votes < total_votes):
        votes[1] = candidate_votes
        votes[0] = row["Candidate"]
    
    
    print("Election Results")
    print("Total Votes " + str(votes))

#results
    for candidate in candidate_votes:
        print(candidate + " " + str(round(((candidate_votes[candidate]/votes)*100))) + "%" + " (" + str(candidate_votes[candidate]) + ")") 
        candidate_results = (candidate + " " + str(round(((candidate_votes[candidate]/votes)*100))) + "%" + " (" + str(candidate_votes[candidate]) + ")") 
    
winner = sorted(candidate_votes.items(),)
print("Winner: " + str(winner[1]))

#produce written file
text = "analysis.txt"

# Output Files
with open(text, "w") as file:

    file.write("Election Results")
    file.write("\n")
    file.write("------------------------------------------------------------")
    file.write("\n")
    file.write(candidate + " " + str(round(((candidate_votes[candidate]/votes)*100))) + "%" + " (" + str(candidate_votes[candidate]) + ")")
    file.write(str(winner))
    file.write("\n")
    file.write("-------------------------------------------------------------------")
    file.write("\n")
    file.write("Winner: " + str(winner[1]))
    file.write("\n")
    file.write("Total Votes " + str(votes))