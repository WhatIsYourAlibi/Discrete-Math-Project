import pandas as pd
import matplotlib.pyplot as plt
from pathlib import Path


# Function to plot and save diagrams
def plot_and_save(dataframe, density, representation, method, output_dir):
    filtered_data = dataframe[(dataframe['Density'] == density) & (dataframe['Representation'] == representation) & (dataframe['Method'] == method)]

    if not filtered_data.empty:
        plt.figure()
        plt.plot(filtered_data['Size'], filtered_data['AverageTime(ms)'], marker='o')
        plt.title(f'Density {density}, {representation}, {method}')
        plt.xlabel('Size')
        plt.ylabel('AverageTime(ms)')
        plt.grid(True)
        output_file = output_dir / f'density_{density}_{representation}_{method}.jpg'
        plt.savefig(output_file, format='jpg')
        plt.close()


# Load data
tsv_file_path = 'C:\\Users\\38097\\PycharmProjects\\DM_Project_Plots\\experiment_results100_Emir.tsv'
data = pd.read_csv(tsv_file_path, delimiter='\t', decimal=',')

# Replace comma with dot for numeric values and convert columns to appropriate types
data['Density'] = data['Density'].str.replace(',', '.').astype(float)
data['AverageTime(ms)'] = data['AverageTime(ms)'].str.replace(',', '.').astype(float)

# Create output directory
output_dir = Path('diagrams')
output_dir.mkdir(exist_ok=True)

# Generate diagrams
for density in data['Density'].unique():
    for representation in data['Representation'].unique():
        for method in data['Method'].unique():
            plot_and_save(data, density, representation, method, output_dir)

print(f"Diagrams have been saved in {output_dir.absolute()}")
