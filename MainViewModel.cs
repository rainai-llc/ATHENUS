using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AthenusV1.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _statusText = "SYSTEM_READY";

    [ObservableProperty]
    private double _cognitiveLoad = 24.8;

    [ObservableProperty]
    private double _resourceConsumption = 86.1;

    [ObservableProperty]
    private ObservableCollection<string> _auditLogs = new();

    [ObservableProperty] private string _currentChatMessage = "";
    [ObservableProperty] private ObservableCollection<string> _chatMessages = new();
    
    [RelayCommand]
    private void SendChatMessage()
    {
        if (string.IsNullOrWhiteSpace(CurrentChatMessage)) return;
    
        string formattedMsg = $"H: {CurrentChatMessage}";
        ChatMessages.Add(formattedMsg);
        
        // Also log the transmission to the forensic audit log
        AddLog($"CHAT_TRANSMISSION: {CurrentChatMessage}");
        
        CurrentChatMessage = ""; // Clear input
    }

    public MainViewModel()
    {
        _auditLogs.Add("> INITIALIZING_ATHENUS_V1_CORE...");
        _auditLogs.Add("> NODE_IDENTIFIED: AORUS_LAPTOP_ARCH");
    }

    [RelayCommand]
    private void Synthesize()
    {
        StatusText = StatusText == "SYSTEM_READY" ? "SYNTHESIS_ACTIVE" : "SYSTEM_READY";
        AuditLogs.Insert(0, $"> [{DateTime.Now:HH:mm:ss}] {StatusText}");
        
        if (StatusText == "SYNTHESIS_ACTIVE")
        {
            AuditLogs.Insert(0, "> ATTEMPTING_HANDSHAKE_WITH_CLOUDFLARE_TUNNEL...");
        }
    }
}
