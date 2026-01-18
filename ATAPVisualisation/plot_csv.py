import pandas as pd
import matplotlib.pyplot as plt

# Load the CSV file
# Adjust the filename if needed
df = pd.read_csv("data.csv")

# Convert TimeStamp column to datetime
df["TimeStamp"] = pd.to_datetime(df["TimeStamp"], format="%m/%d/%Y %H:%M:%S")

# Sort by timestamp (important for time-series plots)
df = df.sort_values("TimeStamp")

# Optional: handle duplicate timestamps by averaging values
df = df.groupby("TimeStamp", as_index=False)["Value"].mean()

# Create the plot
plt.figure(figsize=(12, 6))
# plt.plot(df["TimeStamp"], df["Value"], marker="o", linestyle="-")
plt.plot(df["TimeStamp"], df["Value"], linestyle="-")
# Labels and title
plt.xlabel("Time")
plt.ylabel("Closing Price")
plt.title("TFM FYF0026.Z0026")

# Improve readability
plt.grid(True)
plt.tight_layout()
plt.xticks(rotation=45)

# Show the plot
plt.show()
