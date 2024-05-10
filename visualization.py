def plot_raw(raw,start,duration):
    raw.plot(duration=duration, start=start)
    print()
def plot_psd(raw):
    raw.compute_psd().plot()
    print()