using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDevkit;
using JRPC_Client;
using System.Diagnostics;

namespace Armor_Multiverse
{
    public partial class ArmorMultiverse : Form
    {
        IXboxConsole RGH;

        bool isStarted = false;
        int gamertagState = 1;

        readonly uint visorAddress = 0x83959D53;
        readonly uint helmetAddress = 0x83959D5E;
        readonly uint shoulderLAddress = 0x83959D5F;
        readonly uint shoulderRAddress = 0x83959D60;
        readonly uint chestAddress = 0x83959D61;
        readonly uint wristAddress = 0x83959D62;
        readonly uint utilityAddress = 0x83959D63;
        readonly uint kneeGuardsAddress = 0x83959D64;

        Dictionary<string, Dictionary<byte, string>> allGroups = new Dictionary<string, Dictionary<byte, string>>()
        {
            { "Helmet", new Dictionary<byte, string>()
                {
                    { 0x00, "Mark V Base" },
                    { 0x01, "Mark V UA" },
                    { 0x02, "Mark V UA/HUL" },
                    { 0x03, "CQC Base" },
                    { 0x04, "CQC CBRN" },
                    { 0x05, "CQC UA/HUL" },
                    { 0x06, "Military Police Base" },
                    { 0x07, "Military Police CBRN/HURS" },
                    { 0x08, "Military Police HURS/CNM" },
                    { 0x09, "ODST Base" },
                    { 0x0A, "ODST UA/CNM" },
                    { 0x0B, "ODST CBRN/HUL" },
                    { 0x0C, "Hazop Base" },
                    { 0x0D, "Hazop CBRN/HUL" },
                    { 0x0E, "Hazop CNM/I" },
                    { 0x0F, "EOD Base" },
                    { 0x10, "EOD CNM" },
                    { 0x11, "EOD UA/NUL" },
                    { 0x12, "Operator Base" },
                    { 0x13, "Operator UA/HUL" },
                    { 0x14, "Operator CNM" },
                    { 0x15, "Grenadier Base" },
                    { 0x16, "Grenadier UA" },
                    { 0x17, "Grenadier UA/FC" },
                    { 0x18, "Air Assault Base" },
                    { 0x19, "Air Assault UA/CNM" },
                    { 0x1A, "Air Assault FCI" },
                    { 0x1B, "Scout Base" },
                    { 0x1C, "Scout HURS" },
                    { 0x1D, "Scout CBRN/CNM" },
                    { 0x1E, "EVA Base" },
                    { 0x1F, "EVA CNM" },
                    { 0x20, "EVA AUA/HUL3" },
                    { 0x21, "JFO Base" },
                    { 0x22, "JFO HUL/I" },
                    { 0x23, "JFO UA" },
                    { 0x24, "Commando Base" },
                    { 0x25, "Commando CBRN/CNM" },
                    { 0x26, "Commando UA/FCI2" },
                    { 0x27, "Mjolnir Mk V Base" },
                    { 0x28, "Mjolnir Mk V CNM" },
                    { 0x29, "Mjolnir Mk V UA" },
                    { 0x2A, "Pilot Base" },
                    { 0x2B, "Pilot HUL3" },
                    { 0x2C, "Pilot UA/HUL3" },
                    { 0x2D, "Pilot Haunted" },
                    { 0x2E, "Security Base" },
                    { 0x2F, "Security UA/HUL" },
                    { 0x30, "Security CBRN/CNM" },
                    { 0x31, "Mjolnir Mk VI Base" },
                    { 0x32, "Mjolnir Mk VI FCI2" },
                    { 0x33, "Mjolnir Mk VI UA/HULI" },
                    { 0x34, "CQB Base" },
                    { 0x35, "CQB HURS/CNM" },
                    { 0x36, "CQB UA/HUL" },
                    { 0x37, "Gungnir Base" },
                    { 0x38, "Gungnir HURS" },
                    { 0x39, "Gungnir CBRN" },
                    { 0x3A, "Recon Base" },
                    { 0x3B, "Recon HUL" },
                    { 0x3C, "Recon UA/HUL3" },
                    { 0x3D, "EVA Base" },
                    { 0x3E, "EVA CNM" },
                    { 0x3F, "EVA HUL3" }
                }
            },
            { "LShoulder", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "FJ/Para" },
                    { 0x02, "Hazop" },
                    { 0x03, "JFO" },
                    { 0x04, "Recon" },
                    { 0x05, "UA/Multi-Threat" },
                    { 0x06, "Jump Jet" },
                    { 0x07, "EVA" },
                    { 0x08, "Gungnir" },
                    { 0x09, "UA/Base Security" },
                    { 0x0A, "CQC" },
                    { 0x0B, "Operator" },
                    { 0x0C, "Commando" },
                    { 0x0D, "Grenadier" },
                    { 0x0E, "Sniper" },
                    { 0x0F, "Mjolnir Mk. V" },
                    { 0x10, "Security" },
                    { 0x11, "ODST" }
                }
            },
            { "RShoulder", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "FJ/Para" },
                    { 0x02, "Hazop" },
                    { 0x03, "JFO" },
                    { 0x04, "Recon" },
                    { 0x05, "UA/Multi-Threat" },
                    { 0x06, "Jump Jet" },
                    { 0x07, "EVA" },
                    { 0x08, "Gungnir" },
                    { 0x09, "UA/Base Security" },
                    { 0x0A, "CQC" },
                    { 0x0B, "Operator" },
                    { 0x0C, "Commando" },
                    { 0x0D, "Grenadier" },
                    { 0x0E, "Sniper" },
                    { 0x0F, "Mjolnir Mk. V" },
                    { 0x10, "Security" },
                    { 0x11, "ODST" }
                }
            },
            { "Chest", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "Grenadeless UA/Base Security [W] (Modded Variant)" },
                    { 0x02, "Grenadeless UA/Multi-Threat [W] (Modded Variant)" },
                    { 0x03, "HP/Halo" },
                    { 0x04, "UA/Counterassault" },
                    { 0x05, "Tactical/LRP" },
                    { 0x06, "Tactical/Recon" },
                    { 0x07, "Collar/Grenadier" },
                    { 0x08, "Tactical/Patrol" },
                    { 0x09, "Collar/Breacher" },
                    { 0x0A, "Assault/Sapper" },
                    { 0x0B, "Assault/Commando" },
                    { 0x0C, "HP/Parafoil" },
                    { 0x0D, "Collar/Grenadier [UA]" },
                    { 0x0E, "UA/Multi-Threat [W]" },
                    { 0x0F, "UA/Base Security [W]" },
                    { 0x10, "Collar/Breacher [R]" },
                    { 0x11, "HP/Parafoil [R]" },
                    { 0x12, "Assault/Sapper [R]" },
                    { 0x13, "UA/ODST" }
                }
            },
            { "Wrist", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "UA/Buckler" },
                    { 0x02, "UA/Bracer" },
                    { 0x03, "Tactical/Tacpad" },
                    { 0x04, "Assault/Breacher" },
                    { 0x05, "Tactical/UGPS" }
                }
            },
            { "Utility", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "Tactical/Softcase" },
                    { 0x02, "UA/CHOBHAM" },
                    { 0x03, "UN/NxRA" },
                    { 0x04, "Tactical/Trauma Kit" },
                    { 0x05, "Tactical/Hardcase" }
                }
            },
            { "Visor", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "Silver" },
                    { 0x02, "Blue" },
                    { 0x03, "Gold" },
                    { 0x04, "Black" }
                }
            },
            { "Knee Guards", new Dictionary<byte, string>()
                {
                    { 0x00, "Default" },
                    { 0x01, "FJ/Para" },
                    { 0x02, "Gungnir" },
                    { 0x03, "Grenadier" }
                }
            }
        };

        public ArmorMultiverse()
        {
            InitializeComponent();
            ConnectToConsoleAsync();
        }

        public void SetMemory(uint address, byte[] data)
        {
            Console.WriteLine($"Address: 0x{address:X8}, Data: {BitConverter.ToString(data)}");
            JRPC.SetMemory(RGH, address, data);
        }

        // Helper method to calculate the current combination index based on the currentIndex array
        static int GetCurrentCombinationIndex(int[] currentIndex, int[] groupCounts)
        {
            int index = currentIndex[currentIndex.Length - 1];
            int multiplier = 1;
            for (int i = currentIndex.Length - 2; i >= 0; i--)
            {
                multiplier *= groupCounts[i + 1];
                index += currentIndex[i] * multiplier;
            }
            return index;
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (isStarted == false)
            {
                var askUser = MessageBox.Show("Using this tool may result in PERMANENT DAMAGE to your Halo: Reach save data. I strongly recommend using a burner account or a temporary profile to ensure your save data remains safe.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (askUser == DialogResult.Cancel) return;
                isStarted = true;
                startButton.Enabled = false;
                resumeRevertTextbox.Enabled = false;
            }

            // Create a stopwatch to measure the elapsed time
            Stopwatch totalTimeStopwatch = new Stopwatch();
            totalTimeStopwatch.Start();

            // Sets the cR amount to zero
            RGH.WriteInt32(0x8390F348, 0);

            // Nulls out gamertag
            JRPC.SetMemory(RGH, 0xC03428FC, new byte[30] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            JRPC.SetMemory(RGH, 0x83959D74, new byte[26] { 0x00, 0x40, 0x00, 0x48, 0x00, 0x79, 0x00, 0x62, 0x00, 0x72, 0x00, 0x69, 0x00, 0x64, 0x00, 0x73, 0x00, 0x45, 0x00, 0x67, 0x00, 0x6F, 0x00, 0x00, 0x00, 0x00 });

            // Get the number of groups
            int amountProcessed = 0;

            // Get the keys of all groups (group names)
            string[] groupNames = new string[]
            {
                "Helmet",
                "LShoulder",
                "RShoulder",
                "Chest",
                "Wrist",
                "Utility",
                "Visor",
                "Knee Guards"
            };

            // Get the count of options in each group
            int[] groupCounts = new int[groupNames.Length];
            for (int i = 0; i < groupNames.Length; i++)
            {
                groupCounts[i] = allGroups[groupNames[i]].Count;
            }

            // Calculate the total number of combinations
            int totalCombinations = 1;
            foreach (int count in groupCounts)
            {
                totalCombinations *= count;
            }

            // Check if the user entered the total loops already processed
            string userInput = resumeRevertTextbox.Text;
            int loopsProcessed;
            while (!int.TryParse(userInput, out loopsProcessed) || loopsProcessed < 0 || loopsProcessed >= totalCombinations)
            {
                break;
            }

            // Checks if the userInput exceeds the totalCombonations possible
            var amountToAdd = int.Parse(userInput);
            if (amountToAdd > totalCombinations)
            {
                amountToAdd = 0;
                Console.WriteLine("Number exceeded: 298598400, starting from: 0");
            }

            // Adds the userInput to amountProcessed
            amountProcessed += amountToAdd;

            // Calculate the starting index based on the number of loops already processed
            int[] currentIndex = new int[groupNames.Length];
            for (int i = groupNames.Length - 1; i >= 0; i--)
            {
                int count = groupCounts[i];
                currentIndex[i] = loopsProcessed % count;
                loopsProcessed /= count;
            }

            // Create a separate stopwatch for measuring the loop time
            Stopwatch loopTimeStopwatch = new Stopwatch();

            // Check if the user has reached the final combination
            if (loopsProcessed == totalCombinations)
            {
                Console.WriteLine("You've reached the final combination. No more combinations to process.");
                MessageBox.Show("No more combinations to process.", "You've reached the final combination.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                // Create an array to store the previous combination
                int[] prevCombination = new int[groupNames.Length];
                for (int i = 0; i < groupNames.Length; i++)
                {
                    prevCombination[i] = -1; // Initialize to -1 (an invalid value) to ensure all groups are updated in the first loop
                }

                // Loop through all possible combinations starting from the resume point
                while (currentIndex[0] < groupCounts[0])
                {
                    if (amountProcessed >= 298598400)
                    {
                        MessageBox.Show($"Goal: ({amountProcessed}) was reached!", "Breakpoint");
                    }

                    loopTimeStopwatch.Restart(); // Restart the loop time stopwatch for each iteration

                    // Calculate the percentage of completion
                    double completionPercentage = (double)(loopsProcessed + GetCurrentCombinationIndex(currentIndex, groupCounts)) / totalCombinations * 100.0;

                    // Print the current combination
                    for (int i = 0; i < groupNames.Length; i++)
                    {
                        byte value = (byte)currentIndex[i];
                        //Console.WriteLine(groupNames[i] + ": " + allGroups[groupNames[i]][value]);
                    }

                    // Compare the current combination with the previous combination
                    for (int i = 0; i < groupNames.Length; i++)
                    {
                        if (currentIndex[i] != prevCombination[i])
                        {
                            // SetMemory with the selected byte for the group that has changed
                            switch (i)
                            {
                                case 0: // Helmet
                                    SetMemory(helmetAddress, new byte[] { (byte)currentIndex[0] });
                                    break;
                                case 1: // Shoulder L
                                    SetMemory(shoulderLAddress, new byte[] { (byte)currentIndex[1] });
                                    break;
                                case 2: // Shoulder R
                                    SetMemory(shoulderRAddress, new byte[] { (byte)currentIndex[2] });
                                    break;
                                case 3: // Chest
                                    SetMemory(chestAddress, new byte[] { (byte)currentIndex[3] });
                                    break;
                                case 4: // Wrist
                                    SetMemory(wristAddress, new byte[] { (byte)currentIndex[4] });
                                    break;
                                case 5: // Utility
                                    SetMemory(utilityAddress, new byte[] { (byte)currentIndex[5] });
                                    break;
                                case 6: // Visor
                                    SetMemory(visorAddress, new byte[] { (byte)currentIndex[6] });
                                    break;
                                case 7: // Knee Guards
                                    SetMemory(kneeGuardsAddress, new byte[] { (byte)currentIndex[7] });
                                    break;
                            }
                        }
                    }

                    // Update the previous combination with the current combination
                    Array.Copy(currentIndex, prevCombination, groupNames.Length);

                    loopTimeStopwatch.Stop();
                    Console.WriteLine($"Loop Time: {loopTimeStopwatch.Elapsed}");
                    loopTimeTextbox.Text = $"{loopTimeStopwatch.Elapsed.TotalSeconds}";

                    elapsedTimeTextbox.Text = totalTimeStopwatch.Elapsed.ToString();

                    Console.WriteLine($"Completion: {completionPercentage:F2}%");
                    percentageTextbox.Text = $"{completionPercentage:F2}%";

                    // Writes the amountProcessed to the cR memory location for a visible in-game counter
                    RGH.WriteInt32(0x8390F348, amountProcessed);

                    // Writes the service tag to prevent it from disappearing during usage
                    JRPC.SetMemory(RGH, 0x83959D74, new byte[26] { 0x00, 0x40, 0x00, 0x48, 0x00, 0x79, 0x00, 0x62, 0x00, 0x72, 0x00, 0x69, 0x00, 0x64, 0x00, 0x73, 0x00, 0x45, 0x00, 0x67, 0x00, 0x6F, 0x00, 0x00, 0x00, 0x00 });

                    // Gamertag animation
                    if (amountProcessed % 1 == 0)
                    {
                        byte[][] patterns = new byte[21][]
                        {
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3D, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                            new byte[30] { 0x00, 0x5B, 0x00, 0x3E, 0x00, 0x5F, 0x00, 0x3C, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x3D, 0x00, 0x5D },
                        };

                        if (gamertagState >= patterns.Length)
                        {
                            gamertagState = 1;
                        }

                        JRPC.SetMemory(RGH, 0xC03428FC, patterns[gamertagState - 1]);
                        gamertagState++;
                    }

                    amountTotalTextbox.Text = amountProcessed + "/" + totalCombinations.ToString();
                    currentPatternTextbox.Text = $"{currentIndex[0]}" + ", " + $"{currentIndex[1]}" + ", " + $"{currentIndex[2]}" + ", " + $"{currentIndex[3]}" + ", " + $"{currentIndex[4]}" + ", " + $"{currentIndex[5]}" + ", " + $"{currentIndex[6]}" + ", " + $"{currentIndex[7]}";

                    loopsProcessed++;
                    amountProcessed++;

                    // Increment the rightmost index and propagate the carry
                    currentIndex[groupNames.Length - 1]++;
                    for (int i = groupNames.Length - 1; i > 0 && currentIndex[i] >= groupCounts[i]; i--)
                    {
                        currentIndex[i] = 0;
                        currentIndex[i - 1]++;
                    }

                    await Task.Delay(1);
                }
            }
        }

        public void ConnectToConsoleAsync()
        {
            if (RGH.Connect(out RGH))
            {
                try
                {
                    connectButton.Text = "Connected\n(click to refresh)";

                    Console.WriteLine("Connected to console: " + RGH.XboxIP() + " (" + JRPC.ConsoleType(this.RGH).ToString() + ")");
                    connectionTextbox.Text = RGH.XboxIP();
                    RGH.CallVoid(JRPC.ThreadType.Title, "xam.xex", 656, 34, 0xFF, 2, $"Connected! ('{RGH.XboxIP()}')".ToString().ToWCHAR(), 1);

                    if (RGH.XamGetCurrentTitleId() == 0x4D53085B)
                    {
                        if (JRPC.ReadFloat(RGH, 0x82430204) != 192439)
                        {
                            JRPC.WriteFloat(RGH, 0x82430204, 192439f); // disable mapchecks if they're not already patched out
                            Console.WriteLine($"Disabled mapchecks: (0x82430204 - {JRPC.ReadFloat(RGH, 0x82430204)}f)");
                        }

                        // Give bungie nameplate
                        JRPC.SetMemory(RGH, 0x833CD032, new byte[2] { 0x30, 0x05 });
                        // Give ultrawhite primary/secondary
                        JRPC.SetMemory(RGH, 0x83959D4B, new byte[] { 0x1E });
                        JRPC.SetMemory(RGH, 0x83959D4F, new byte[] { 0x1E });
                    }
                    else
                    {
                        Console.WriteLine($"Halo: Reach isn't running! :(");
                        RGH.CallVoid(JRPC.ThreadType.Title, "xam.xex", 656, 34, 0xFF, 2, $"Halo: Reach isn't running! (It's kinda required)".ToString().ToWCHAR(), 1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong while trying to connect to the console. Exception: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectToConsoleAsync();
        }

        private void resumeRevertTextbox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(resumeRevertTextbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                resumeRevertTextbox.Text = "0";
            }
        }
    }
}